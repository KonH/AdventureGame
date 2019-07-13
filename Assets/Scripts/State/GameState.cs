using System;
using System.Collections.Generic;

namespace AdventureGame.State {
	[Serializable]
	public class GameState {
		public PlayerState         Player    = new PlayerState();
		public List<LocationState> Locations = new List<LocationState>();
	}
}