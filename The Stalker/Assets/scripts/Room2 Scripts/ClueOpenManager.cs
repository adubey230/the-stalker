using UnityEngine;
using System;
using UnityEngine.UI;




public class ClueOpenManager : MonoBehaviour
    {
        [Serializable] private struct CluePapersInfo
        {
            public String name;
            public DeskPapers paper;
        };

        [SerializeField] private CluePapersInfo[] cluePaperInfos;

        public void DisableOtherPaperRaycastTarget(String thisPaperName)
        {
            foreach (CluePapersInfo cluePaperInfo in cluePaperInfos)
            {
                if (cluePaperInfo.name != thisPaperName)
                {
                    cluePaperInfo.paper.GetComponent<Image>().raycastTarget = false;
                    Debug.Log("Raycast set to false for: " + cluePaperInfo.name);
                }
            }
        }

        public void EnableAllPaperRaycastTarget()
        {
            foreach (CluePapersInfo cluePaperInfo in cluePaperInfos)
            {
                cluePaperInfo.paper.GetComponent<Image>().raycastTarget = true;
            }
        }
    }
