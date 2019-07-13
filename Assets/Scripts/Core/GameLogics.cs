using System.Collections.Generic;
using AdventureGame.Config;
using AdventureGame.State;
using UnityEngine;

namespace AdventureGame.Core {
	public class GameLogics {
		readonly ConfigRoot _config;
		readonly GameState  _state;
		
		public GameLogics(ConfigRoot config, GameState state) {
			_config = config;
			_state  = state;
		}
		
		public void PrepareNewState() {
			_state.Player.Location = _config.Settings.StartLocation;
		}
		
		public string GetMainText() {
			var parts               = new List<string>();
			var location            = GetPlayerLocationConfig();
			var locationDescription = location.Description;
			parts.Add(locationDescription);
			var actions = GetActions();
			foreach ( var (action, isActive) in actions ) {
				var text = isActive ? action.Description : action.HiddenDescription;
				if ( !string.IsNullOrWhiteSpace(text) ) {
					parts.Add(text);
				}
			}
			foreach ( var text in _state.Player.ActionTexts ) {
				parts.Add(text);
			}
			var str = string.Join("\n", parts.ToArray());
			return str;
		}

		public List<(ActionConfig, bool)> GetActions() {
			var result   = new List<(ActionConfig, bool)>();
			var location = GetPlayerLocationConfig();
			AddAvailableActions(location.Actions, result);
			foreach ( var item in _state.Player.Items ) {
				var itemConfig = _config.Items.Find(i => i.Name == item.Name);
				Debug.Assert(itemConfig != null, $"No config fo item '{item.Name}'!");
				AddAvailableActions(itemConfig.Actions, result);
			}
			return result;
		}

		void AddAvailableActions(List<ActionConfig> source, List<(ActionConfig, bool)> destination) {
			foreach ( var action in source ) {
				if ( !IsActionAvailable(action) ) {
					continue;
				}
				destination.Add((action, IsActionActive(action)));
			}
		}

		public void Execute(ActionConfig action) {
			_state.Player.ActionTexts.Clear();
			var isSatisfied = IsActionSatisfied(action);
			var results = isSatisfied ? action.Results : action.HiddenResults;
			foreach ( var result in results ) {
				result.Apply(_state);
			}
			if ( isSatisfied ) {
				GetPlayerLocationState().Events.Add(new EventState { Name = action.Name });
			}
		}

		LocationConfig GetPlayerLocationConfig() {
			var name = _state.Player.Location;
			var config = _config.Locations.Find(l => l.Name == name);
			return config;
		}

		LocationState GetPlayerLocationState() {
			var name = _state.Player.Location;
			var state = _state.Locations.Find(l => l.Name == name);
			if ( state == null ) {
				state = new LocationState { Name = name };
				_state.Locations.Add(state);
			}
			return state;
		}

		bool IsActionAvailable(ActionConfig action) {
			if ( _state.Player.IsEnd ) {
				return false;
			}
			if ( action.Single ) {
				if ( GetPlayerLocationState().Events.Find(s => s.Name == action.Name) != null ) {
					return false;
				}
			}
			return true;
		}

		bool IsActionActive(ActionConfig action) {
			return IsActionSatisfied(action) || (action.HiddenResults.Count > 0);
		}

		bool IsActionSatisfied(ActionConfig action) {
			foreach ( var condition in action.Conditions ) {
				if ( !condition.IsSatisfied(_state) ) {
					return false;
				}
			}
			return true;
		}
	}
}