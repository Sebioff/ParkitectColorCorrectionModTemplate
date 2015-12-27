using System;
using UnityEngine;

namespace ColorCorrection {
	public class Main : IMod {
		private GameObject _go;
		
		public void onEnabled() {
			_go = new GameObject(Name);
			ColorCorrection colorCorrection = _go.AddComponent<ColorCorrection>();
			colorCorrection.modPath = Path != null ? Path : System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
		}
		
		public void onDisabled() {
			UnityEngine.Object.Destroy(_go);
		}
		
		public string Name {
			get { return "ColorCorrection"; }
		}
		
		public string Description {
			get { return "Changes the colors of the game."; }
		}

		// PN mod location path
		public string Path { get; set; }
	}
}

