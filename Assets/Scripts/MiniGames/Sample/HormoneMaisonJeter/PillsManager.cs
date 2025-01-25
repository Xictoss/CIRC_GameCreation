using System.Collections.Generic;
using System.Linq;
using LTX.Singletons;
using TMPro;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class PillsManager : MonoSingleton<PillsManager>
    {
        [SerializeField] private List<PillLink> pillLinks;
        [SerializeField] private TMP_Text pillUIPrefab;
        [SerializeField] private Transform nameListParent;
        
        private List<Pills> endPills;
        private Dictionary<Pills, PillLink> pillsDict;
        
        public bool IsDone { get; private set; }
        protected override void Awake()
        {
            base.Awake();

            pillsDict = new Dictionary<Pills, PillLink>();
            endPills = new List<Pills>();
            foreach (PillLink pillLink in pillLinks)
            {
                pillsDict.Add(pillLink.pills, pillLink);
                pillLink.pillsText.text = pillLink.pillsName;
                pillLink.pills.isHormonal = pillLink.isHormonal;

                if (pillLink.isHormonal)
                {
                    pillLink.pills.OnEnd += OnPillsEnd;
                    TMP_Text pill = Instantiate(pillUIPrefab, nameListParent);
                    pillLink.listPills = pill;
                    pillLink.listPills.text = pillLink.pillsName;
                }
            }
        }

        private void OnPillsEnd(Pills pills)
        {
            pillsDict[pills].listPills.color = Color.red;
            
            endPills.Add(pills);
            if (endPills.Count >= pillLinks.Where(pill => pill.isHormonal).ToList().Count)
            {
                IsDone = true;
            }
        }
    }
}