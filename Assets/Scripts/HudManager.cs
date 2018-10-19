namespace STUDENT_NAME
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;
	using SDD.Events;
    using TMPro;

    public class HudManager : Manager<HudManager>
	{
        [Header("HudManager")]
        [SerializeField]
        private TextMeshProUGUI LabelScore;
        [SerializeField]
        private TextMeshProUGUI LabelWaste;
        [SerializeField]
        private TextMeshProUGUI LabelTimer;

		#region Manager implementation
		protected override IEnumerator InitCoroutine()
		{
			yield break;
		}
		#endregion

		#region Callbacks to GameManager events
		protected override void GameStatisticsChanged(GameStatisticsChangedEvent e)
		{
            LabelScore.text = e.eScore.ToString();
            LabelWaste.text = e.eNWaste.ToString();
            LabelTimer.text = e.eTimer.ToString();
		}
		#endregion

	}
}