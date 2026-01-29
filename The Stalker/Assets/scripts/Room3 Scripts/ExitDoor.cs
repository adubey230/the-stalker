using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ExitDoor : MonoBehaviour
{
    [SerializeField] private string Password;
    [SerializeField] private string Current_guess;
    [SerializeField] private TMP_Text[] Guess_text;
    [SerializeField] private GameObject cabinet;
    [SerializeField] private GameObject cabinet_correct;
    public bool drawerOpened;
    private float lock_timer=1000;
    private bool correct;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        drawerOpened=false;
    }

    // Update is called once per frame
    void Update()
    {
        if (lock_timer != 1000)
        {
            lock_timer -= Time.deltaTime;

            if (lock_timer < 0 && correct)
            {
                drawerOpened = true;
                lock_timer = 1000;
            }
            else if (lock_timer < 0 && !correct)
            {
                incorrect();
                lock_timer = 1000;
            }
        }
    }
    
    public void OnButtonClick(string number){
        Current_guess += number;
        Check_guess();
    }
    private void Check_guess()
    {
        int index = Current_guess.Length - 1;

        if (index < Guess_text.Length)
        {
            Guess_text[index].text = Current_guess.Substring(index, 1);
        }

        if (Current_guess.Length == 6)
        {
            if (Password == Current_guess)
            {
                cabinet.SetActive(false);
                cabinet_correct.SetActive(true);
                lock_timer = 1f;
                correct = true;
            }
            else
            {
                lock_timer = 1f;
                correct = false;
            }
        }
    }

    public void OpenDrawer(){
     drawerOpened =true;
            
    }

    public void incorrect(){
         Current_guess="";
            for(int i =0;i<Guess_text.Length;i++){
                Guess_text[i].text= "";
            }

    }
}
