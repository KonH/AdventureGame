using UnityEngine;
using AdventureGame.Config;
using AdventureGame.State;
using AdventureGame.UI;
using AdventureGame.Utils;

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
			return Serialization.Load<ConfigRoot>(ConfigAsset.text);
		}

		void UpdateState() {
			RenderMainText();
			RenderActions();
		}

		void RenderMainText() {
			SceneSetup.MainText.text = _logics.GetMainText();
		}

		void RenderActions() {
			var actions = _logics.GetActionsToDisplay();
			for ( var i = 0; i < SceneSetup.Buttons.Count; i++ ) {
				var button = SceneSetup.Buttons[i];
				var isActive = actions.Length > i;
				button.gameObject.SetActive(isActive);
				if ( isActive ) {
					var action = actions[i];
					InitAction(action, button);
				}
			}
		}

		void InitAction(ActionConfig action, ActionButton button) {
			button.Text.text = action.Name;
			button.Button.onClick.RemoveAllListeners();
			button.Button.onClick.AddListener(() => OnAction(action));
		}

		void OnAction(ActionConfig action) {
			_logics.Execute(action);
			UpdateState();
		}
	}
}
