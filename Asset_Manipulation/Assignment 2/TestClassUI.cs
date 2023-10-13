//using GUI;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.Drawing;

//namespace Assignment_2
//{
//    public class TestClassUI
//    {
//        private Form form;
//        private ImageController imageController;

//        public TestClassUI()
//        {
//            form = new ImageView(); // Replace "YourForm" with the actual form class name
//            imageController = new ImageController();

//            // Attach event handlers
//            form.OpenToolStripMenuItem_Click += OpenToolStripMenuItem_Click;
//            form.NextButton_Click += NextButton_Click;
//            form.PreviousButton_Click += PreviousButton_Click;
//            form.RotateButton_Click += RotateButton_Click;
//            form.FlipButton_Click += FlipButton_Click;
//            form.PictureBox_Click += PictureBox_Click;
//        }

//        public void Run()
//        {
//            form.Show(); // Show the form
//        }

//        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
//        {
//            OpenFileDialog openFileDialog = new OpenFileDialog();
//            openFileDialog.Multiselect = true;
//            openFileDialog.Filter = "PNG Files|*.png";

//            if (openFileDialog.ShowDialog() == DialogResult.OK)
//            {
//                imageController.LoadImages(openFileDialog.FileNames);
//                List<Image> thumbnails = imageController.GetImageThumbnails();
//                form.UpdateThumbnails(thumbnails); // Update the thumbnails list on the form
//            }
//        }

//        private void NextButton_Click(object sender, EventArgs e)
//        {
//            form.ShowNextImage(imageController.GetImageThumbnails());
//        }

//        private void PreviousButton_Click(object sender, EventArgs e)
//        {
//            form.ShowPreviousImage(imageController.GetImageThumbnails());
//        }

//        private void RotateButton_Click(object sender, EventArgs e)
//        {
//            imageController.RotateImage();
//            form.UpdateImage(imageController.GetSelectedImage().Image);
//        }

//        private void FlipButton_Click(object sender, EventArgs e)
//        {
//            imageController.FlipImage();
//            form.UpdateImage(imageController.GetSelectedImage().Image);
//        }

//        private void PictureBox_Click(object sender, EventArgs e)
//        {
//            form.SelectImage(imageController.GetSelectedImage().Image);
//        }
//    }
//}
