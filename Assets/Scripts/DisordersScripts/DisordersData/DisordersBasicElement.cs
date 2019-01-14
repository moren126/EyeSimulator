namespace EyeSimulator.Disorders.Data {

	public abstract class DisordersBasicElement {

		public DisorderType Type { get; set; }
		public int ID { get; set; }
		public string Name { get; set; }

		public DisordersBasicElement() {

		}

	}

}