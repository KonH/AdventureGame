using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AdventureGame.UI {
	public class ActionButton : MonoBehaviour {
		public Button   Button;
		public TMP_Text Text;

		void Awake() {
			Button.onClick.AddListener(OnClick);
		}

		void OnClick() {
			
		}
	}
}