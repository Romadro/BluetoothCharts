
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace BluetoothChat
{
	class GraphicsSurfaceView : SurfaceView, ISurfaceHolderCallback
	{
		PointsCloud points;
		DrawThread drawThread;

		public GraphicsSurfaceView(Context context, Android.Util.IAttributeSet attr) : base(context, attr){
			points = new PointsCloud ();
			this.Holder.AddCallback (this);
		}

		public void AddPoint(int x, int y, int z){
			points.AddPoint (new Point(x,y,z));
			drawThread.Redraw (points, 5);
		}

		public void ToogleGraph(int numb){
			switch (numb) {
				case 0:
					PointsCloud.x = !PointsCloud.x;
					break;
				case 1:
					PointsCloud.y = !PointsCloud.y;
					break;
				case 2:
					PointsCloud.z = !PointsCloud.z;
					break;
				case 3:
					PointsCloud.v = !PointsCloud.v;
					break;
			}
			drawThread.Redraw (points, 5);
		}

		public void SurfaceChanged (ISurfaceHolder holder, Android.Graphics.Format format, int width, int height)
		{

		}

		public void SurfaceCreated (ISurfaceHolder holder)
		{
			drawThread = new DrawThread(holder);
			drawThread.SetRunning(true);
			drawThread.Start();
		}

		public void SurfaceDestroyed (ISurfaceHolder holder)
		{
			bool retry = true;
			// завершаем работу потока
			drawThread.SetRunning(false);
			while (retry) {
				try{
					drawThread.Join();
					retry = false;
				}
				catch(Exception)
				{ }
			}
		}
	}
}

