using System;

namespace AssemblyCSharp
{
	public class Quest
	{
		private string qTitle;	// the title
		private string qDesc;	// short description
		private string qState; 	// state of quest: pending, active or finished
		private string qReward;	//reward for completion
		private int qNum; 		// # number

		public Quest (string qTitle, string qDesc, string qReward, string qState, int qNum)
		{
			this.qTitle = qTitle;
			this.qDesc = qDesc;
			this.qState = qState;
			this.qReward = qReward;
			this.qNum = qNum;
		}
		public string GetqState (){	 //This will be used to refrence if the current quest is finished
			return qState;
		}

		//\n NOTICE ME!
		// Move everything below this to GameController, once finished. Holding this here for now fo easier management.
		//\n

		Quest currQuest;
		int currQuestId;


		void Start () {
			currQuestId = 1;
			currQuest = new Quest ("Apples!", "Retrieve an apple for <NPC>", "Directions out of dungeon, Karma  +2", "pending", 1);
		}

		void OnTriggerEnter () {
			switch (currQuestId)
			{
			case 1:
				if(currQuest.GetqState() == "pending"){
					//Make my GUITextures (background,button Accept,button Decline) visible
					//Set my TextMesh text to current quest title and description and make it visible
					//Activate script attached to Button GUITextures
				}
				else if(currQuest.GetqState() == "active"){
					//Show GUI for active quest this time
				}
				else if(currQuest.GetqState() == "finished"){
					//Show GUI for finnish quest
					//Add reward to player
					currQuest = new Quest("Out","Get out of the dungeon", "Avoid execution, Karma -1","pending", 2);
					currQuestId++;
				}
				break;

			case 2:
				if (currQuest.GetqState () == "pending") {
					//Make my GUITextures (background,button Accept,button Decline) visible
					//Set my TextMesh text to current quest title and description and make it visible
					//Activate script attached to Button GUITextures
				} else if (currQuest.GetqState () == "active") {
					//Show GUI for active quest this time
				} else if (currQuest.GetqState () == "finished") {
					//Show GUI for finnish quest
					//Add reward to player
					currQuest = new Quest ("title3", "desc3", "more stuff", "pending", 3);
					currQuestId++;
				}
				break;

			case 3:
				if (currQuest.GetqState () == "pending") {
					//Make my GUITextures (background,button Accept,button Decline) visible
					//Set my TextMesh text to current quest title and description and make it visible
					//Activate script attached to Button GUITextures
				} else if (currQuest.GetqState () == "active") {
					//Show GUI for active quest this time
				} else if (currQuest.GetqState () == "finished") {
					//Show GUI for finnish quest
					//Add reward to player
					currQuest = new Quest ("title4", "des4", "more stuff", "pending", 4);
					currQuestId++;
				}
				break;

			case 4:
				//repeat for q4
				break;

			default:
				break;
			}
		}
	}
}

