using System;
using UnityEngine;
using UnityStandardAssets.ImageEffects;
using System.IO;

namespace ColorCorrection {
	public class ColorCorrection : MonoBehaviour {
		public string modPath;

		void Start() {
			ColorCorrectionLookup colorCorrectionLookup = Camera.main.GetComponent<ColorCorrectionLookup>();
			if (colorCorrectionLookup == null) {
				Debug.LogError("Can't aply color correction effect. The games camera does not have a color correction component attached.");
				return;
			}

			string lutPath = modPath + "/lut.png";
			if (File.Exists(lutPath)) {
				Texture2D lut = new Texture2D(2, 2);
				lut.LoadImage(File.ReadAllBytes(lutPath));
				colorCorrectionLookup.Convert(lut, lutPath);
			}
			else {
				Debug.LogError("Can't load LUT texture from: " + lutPath);
			}
		}
	}
}

