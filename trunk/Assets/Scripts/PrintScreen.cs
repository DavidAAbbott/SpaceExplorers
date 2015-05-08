#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

    public class PrintScreen : MonoBehaviour
    {

	private static PrintScreen instance;
	public static PrintScreen Instance
	{
		get {return instance;}
	}
        #region enums
        public enum EStep
        {
            None,
            Prepare,
            Processing,
            Finished,
        }
        #endregion

        #region member
        [HideInInspector]
        public Texture2D RectTex;
        [HideInInspector]
        public Texture2D BkgTex;

        public KeyCode capture;

        int StartWidth = 1024;
        int StartHeight = 1024;

        protected int mOutputWidth;
        protected int mOutputHeight;
        protected GUIStyle mStyle = new GUIStyle();
        protected Rect mOutputRect;
        protected float mSliderW;
        protected float mSliderH;



        protected float mElapsedTime = 0f;
        protected int mCurTexIndex = 0;
       	float CaptureInterval = 0.02f;
     	float TimeLen = 0.02f;

        public GameObject[] disable;
        protected EStep mStep = EStep.None;
	    protected bool mIsCapturing = false;
        protected float mTotalTime = 0f;
		public string picturePath= "Assets/";
		public string pictureName = "p";


        #endregion


	public void takeShot()
	{
		mStep = EStep.Prepare;
	}



        void RefreshRect()
        {
            int screenWidth = (int)Screen.width;
            int screenHeight = (int)Screen.height;

            mOutputWidth = (int)(screenWidth * 1);
            mOutputHeight = (int)(screenHeight * 1);

            if (Mathf.Abs(mOutputWidth - StartWidth) < 2)
                mOutputWidth = StartWidth;

            if (Mathf.Abs(mOutputHeight - StartHeight) < 2)
                mOutputHeight = StartHeight;



            int left = screenWidth / 2 - mOutputWidth / 2;
            int top = screenHeight / 2 - mOutputHeight / 2;

            mOutputRect = new Rect(left, top, mOutputWidth, mOutputHeight);
        }

 
        IEnumerator CaptureRect()
        {
         //   Effect.Paused = true;
            mIsCapturing = true;
         
		yield return new WaitForEndOfFrame();

            Texture2D tex2D = new Texture2D(mOutputWidth, mOutputHeight, TextureFormat.RGB24, false);
            tex2D.ReadPixels(mOutputRect, 0, 0);
            tex2D.Apply();

 


#if UNITY_WEBPLAYER
            Debug.LogError("Sprite Maker can't run at web player mode!");
#else

      int i =      PlayerPrefs.GetInt("picturecount");

         string   path = picturePath + pictureName + i.ToString() + ".png";
            i++;
            PlayerPrefs.SetInt("picturecount",i);

            byte[] bytes = tex2D.EncodeToPNG();
            System.IO.File.WriteAllBytes(path , bytes);

#endif
            Destroy(tex2D);

            yield return new WaitForSeconds(0.5f);

            mTotalTime -= 0.5f;

            mIsCapturing = false;
            mCurTexIndex++;
        //    Effect.Paused = false;
        }


		void Update()
		{
			
			if (Input.GetKeyDown (capture))
			{
				mStep = EStep.Prepare;
			}
			
		}

        void Awake()
        {

		if (instance != this && instance != this) {
			instance = this;
			DontDestroyOnLoad(gameObject);
		} else
			Destroy (gameObject);



			 StartWidth = Screen.width;
			 StartHeight = Screen.height;
			   RefreshRect();
        }

        void OnDestroy()
        {
            EditorUtility.ClearProgressBar();
        }

        void PrepareCapture()
        {


		if(disable.Length!= 0)
		foreach (GameObject g in disable) 
		{
			g.SetActive (false);
		}


            mElapsedTime += Time.deltaTime;

            if (mElapsedTime > 0.5f)
            {
                mElapsedTime = 0f;
                mStep = EStep.Processing;
                mTotalTime = 0f;
                mIsCapturing = false;
            }
        }

        void ProcessCapture()
        {
            mTotalTime += Time.deltaTime;
            if (mIsCapturing)
                return;

            mElapsedTime += Time.deltaTime;

            if (mElapsedTime < CaptureInterval)
                return;

            mElapsedTime -= CaptureInterval;

            EditorUtility.DisplayProgressBar("Processing", "saving Screenshots", mTotalTime / TimeLen);

           StartCoroutine(CaptureRect());

            if (mCurTexIndex * CaptureInterval > TimeLen)
            {
                mElapsedTime = 0f;
                mCurTexIndex = 0;
                mStep = EStep.Finished;
            }
        }


        void CaptureFinished()
        {
   
            mStep = EStep.None;
         //   Effect.DeActive();
            AssetDatabase.Refresh();
            AssetDatabase.SaveAssets();
            EditorUtility.ClearProgressBar();
          
		if(disable.Length!= 0)
		foreach (GameObject g in disable) 
		{
			g.SetActive (true);
		}
            return;
        }



        public void TakeAphoto()
        {        
            mStep = EStep.Prepare;
        }
        void LateUpdate()
        {
            switch (mStep)
            {
                case EStep.None:
                    return;
                case EStep.Prepare:
                    PrepareCapture();
                    break;
                case EStep.Processing:
                    ProcessCapture();
                    break;
                case EStep.Finished:
                    CaptureFinished();
                    break;
                default:
                    break;
            }
        }
  }

#endif


