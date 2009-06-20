using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ColorFilter
{
    internal class MainController
    {
        private static MainController m_SingletonController;
        private static object m_SyncObject = new object();
        private DigitalImage m_Image;
        private Dictionary<string, ImageObject> m_DetectedObjects = new Dictionary<string,ImageObject>();
        
        private MainController()
        {

        }

        public static MainController GetController()
        {
            if (m_SingletonController == null)
            {
                lock (m_SyncObject)
                {
                    if (m_SingletonController == null)
                    {
                        m_SingletonController = new MainController();
                    }
                }
            }

            return m_SingletonController;
        }

        public void LoadImage(string filename)
        {
            m_Image = new DigitalImage(filename);
        }

        public string GetFilteredImage(Filter filter)
        {
            return m_Image.FilterAndSaveImageToTempFile(filter);
        }

        public string TurnAndSaveToTempFile(int turnPointX, int turnPoinY, int angle, int height, int width, bool correction)
        {
            return m_Image.TurnAndSaveToTempFile(turnPointX, turnPoinY, angle, height,width, correction);
        }

        public void DetectObject(string objectName)
        {
            ImageObject imgObject = m_Image.DetectImageObjects();
            string similarObjectName;

            if (FindSimilarObject(imgObject,out similarObjectName))
            {
                MessageBox.Show(similarObjectName);
            }
            else
            {
                m_DetectedObjects.Add(objectName, imgObject);
                MessageBox.Show("Object detected and saved!");
            }
        }

        private bool FindSimilarObject(ImageObject imgObject, out string objectName)
        {
            objectName = "";
            List<double> cornerAngles = imgObject.CornerAnglesSortedByValue();
            List<double> cornerAnglesSavedObject;
            bool angleCompare;

            foreach (KeyValuePair<string,ImageObject> savedObject in m_DetectedObjects)
            {
                if (savedObject.Value.CornerCount == imgObject.CornerCount)
                {
                    objectName = savedObject.Key;
                    cornerAnglesSavedObject = savedObject.Value.CornerAnglesSortedByValue();
                    angleCompare = true;

                    for (int i = 0; i < cornerAngles.Count; i++)
                    {
                        if (Math.Abs(cornerAngles[i] - cornerAnglesSavedObject[i]) > 0.1)
                        {
                            angleCompare = false;
                            break;
                        }
                    }

                    if (angleCompare)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
