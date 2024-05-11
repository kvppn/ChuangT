using UnityEngine;
using QFramework;

namespace YouChuangThree
{
	public partial class ResController : ViewController,ISingleton
	{
		public GameObject SeedPrefab;

		public static ResController Instance
        {
			get => MonoSingletonProperty<ResController>.Instance;
        }
		void Start()
		{
			// Code Here
		}
		public void OnSingletonInit()
        {

        }
	}
}
