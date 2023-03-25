using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Figures
{

    /*
     * Same Princip as Singleton just extended for Tetris Figures.
     */
    public abstract class BaseFigure<T> where T : BaseFigure<T>, new()
    {
        private int x = -1;
        private int y = -1;
        private static T _instance;
        protected FigurePose figurePose = FigurePose.Top;
        private static object threadSafe = new object();
        protected Dictionary<FigurePose, Action> PoseMethodsMap;
        protected Cell[] cells = new Cell[4];

        public abstract void PositionTop();
        public abstract void PositionBottom();
        public abstract void PositionLeft();
        public abstract void PositionRight();

        public static T Instance
        {
            get { return GetInstance(); }
            set { }
        }

        public static void Draw()
        {
            for (int i = 0; i < Instance.cells.Length; i++)
            {
                BaseElements.Cube(Instance.x + Instance.cells[i].x, Instance.y + Instance.cells[i].y, 0);
            }
        }

        public static T GetInstance()
        {
            lock (threadSafe)
            {
                if (_instance == null)
                {
                    _instance = new T();
                    _instance.PoseMethodsMap = new Dictionary<FigurePose, Action>
                    {
                        { FigurePose.Top, _instance.PositionTop },
                        { FigurePose.Bottom, _instance.PositionBottom },
                        { FigurePose.Left, _instance.PositionLeft },
                        { FigurePose.Right, _instance.PositionRight }
                    };
                }
            }
            return _instance;
        }

        /**
         * Change Figure Pose walking on 4 poses.
         * In short - this method rotates figure 90degress clockwise
         */
        public static void ChangePose()
        {
            if (Instance.figurePose < (FigurePose)3)
            {
                Instance.figurePose += 1;
            }
            else
            {
                Instance.figurePose = (FigurePose)0;
            }

            if (Instance.PoseMethodsMap != null)
            {
                Instance.PoseMethodsMap[Instance.figurePose]();
                Debug.Write("Position changed to ");
                Debug.WriteLine(Instance.figurePose);
            }
            else
            {
                Debug.WriteLine("It is NULL");
            }
        }
        public static int CurrentPose => (int)Instance.figurePose;
        public static void ResetPosition()
        {
            Instance.x = 0;
            Instance.y = 0;
        }

        public static void ChooseThisFigure()
        {
            ResetPosition();
        }
    }
}
