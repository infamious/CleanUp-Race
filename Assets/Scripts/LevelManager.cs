

namespace STUDENT_NAME
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using System.Linq;
	using SDD.Events;

	public class LevelManager : Manager<LevelManager>
	{
        [SerializeField]
        private int m_ObjectifLvl1 = 15;

		#region Manager implementation
		protected override IEnumerator InitCoroutine()
		{
			yield break;
		}
		#endregion

		public override void SubscribeEvents()
		{
			base.SubscribeEvents();
            //Decheterie
            EventManager.Instance.AddListener<ViderDecheterieEvent>(GestionNiveauDechets);
        }

		public override void UnsubscribeEvents()
		{
			base.UnsubscribeEvents();
		}

		protected override void GamePlay(GamePlayEvent e)
		{
		}

		protected override void GameMenu(GameMenuEvent e)
		{
		}

        private void GestionNiveauDechets(ViderDecheterieEvent e)
        {

        }
    }
}