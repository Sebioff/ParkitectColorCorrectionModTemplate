using System;
using UnityEngine;
using UnityStandardAssets.ImageEffects;
using System.IO;

namespace ColorCorrection {
	public class ColorCorrection : MonoBehaviour {
		public string modPath;

		private Lutify lutify;
		private Texture2D defaultLut;

		void Awake() {
			lutify = Camera.main.GetComponent<Lutify>();
			if (lutify == null) {
				Debug.LogError("Can't aply color correction effect. The games camera does not have a color correction component attached.");
			}
		}

		void Start() {
			if (lutify == null) {
				return;
			}

			string lutPath = modPath + "/lut.png";
			if (File.Exists(lutPath)) {
				defaultLut = lutify.LookupTexture;

				Texture2D lut = new Texture2D(2, 2);
				lut.LoadImage(File.ReadAllBytes(lutPath));
				lutify.LookupTexture = lut;
			}
			else {
				Debug.LogError("Can't load LUT texture from: " + lutPath);
			}
		}

		void OnDestroy() {
			if (lutify == null) {
				return;
			}

			lutify.LookupTexture = defaultLut;
		}
	}
}

