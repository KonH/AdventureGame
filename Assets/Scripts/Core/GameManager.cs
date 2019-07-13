using System.Linq;
using AdventureGame.Config;
using AdventureGame.State;
using AdventureGame.UI;
using AdventureGame.Utils;
using UnityEngine;

namespace AdventureGame.Core {
	public class GameManager : MonoBehaviour {
		public SceneSetup SceneSetup;
		public TextAsset  ConfigAsset;
		
		public GameState State = new GameState();

		GameLogics _logics = null;

		void Awake() {
			var config = LoadConfig();
			_logics = new GameLogics(config, State);
			_logics.PrepareNewState();
			UpdateState();
		}

		ConfigRoot LoadConfig() {
			var text = ConfigAsset.text;
			var instance = Serialization.Load<ConfigRoot>(text);
			return instance;
		}

		void UpdateState() {
			RenderMainText();
			RenderActions();
		}

		void RenderMainText() {
			SceneSetup.MainText.text = _logics.GetMainText();
		}

		void RenderActions() {
			var actions = _logics.GetActions().Where(t => t.Item2).Select(t => t.Item1).ToArray();
			for ( var i = 0; i < SceneSetup.Buttons.Count; i++ ) {
				var button = SceneSetup.Buttons[i];
				var isActive = actions.Length > i;
				button.gameObject.SetActive(isActive);
				if ( isActive ) {
					var action = actions[i];
					button.Text.text = action.Name;
					button.Button.onClick.RemoveAllListeners();
					button.Button.onClick.AddListener(() => OnAction(action));
				}
			}
		}

		void OnAction(ActionConfig action) {
			_logics.Execute(action);
			UpdateState();
		}
	}
}
