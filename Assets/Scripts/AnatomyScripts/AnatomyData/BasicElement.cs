namespace EyeSimulator.Anatomy.Data {

	public abstract class BasicElement {

		public EyeCategory Type { get; set; }

		public int ID { get; set; }

		public string NamePolish { get; set; }
		public string NameLatin { get; set; }

		public BasicElement() {

		}

	}

}