using System.Collections.Generic;

namespace EyeSimulator {

	public class EyeElements {

		public List<Element> EyeSocketList { get; set; }
		public List<Element> MusclesList { get; set; }
		public List<Element> NervesList { get; set; }
		public List<Element> EyeballList { get; set; }
		public List<Element> OtherList { get; set; }

		private List<List<Element>> allLists = new List<List<Element>> ();
		public List<List<Element>> AllLists {
			get { return allLists; }
		}

		public void SetEyeElements() {
			allLists.AddRange (new List<List<Element>> {EyeSocketList, MusclesList, NervesList, EyeballList, OtherList});
		}

	}

}