using GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ImageList;

namespace Assignment_2
{
    public partial class ImageView : Form
    {
        /// <summary>
        /// Author: [Joshua Hankins]
        /// V2
        /// </summary>
        private ImageController _imageController;
        private int _currentIndex = 0;
        List<Image> _chosenImages = new List<Image>();
        public ImageView()
        {
            InitializeComponent();
            _imageController = new ImageController();

        }
        // Event handlers

        /// <summary>
        /// Handles the form load event.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Handles the "Open" menu item click event.
        /// </summary>
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "PNG Files|*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _imageController.LoadImages(openFileDialog.FileNames);

                // Update the thumbnails list
                List<Image> thumbnails = _imageController.GetImageThumbnails();
                thumbnailListBox.DataSource = thumbnails;

            }

        }
        /// <summary>
        /// Handles the "Save" menu item click event.
        /// </summary>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Prompt the user to provide a file name and path to save the image
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG Image|*.png";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                // Save the processed image to the specified file path
                _imageController.SaveImage(filePath);

                // Show a success message to the user
                MessageBox.Show("Image saved successfully!");
            }
        }

        /// <summary>
        /// Handles the thumbnail list box selection change event.
        /// </summary>
        private void thumbnailListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFileName = thumbnailListBox.SelectedItem.ToString();
            _imageController.SelectImage(selectedFileName);
            // Check if an image is selected
            if (thumbnailListBox.SelectedItem != null)
            {
                // Get the selected image from the thumbnailListBox
                Image selectedImage = (Image)thumbnailListBox.SelectedItem;

                // Display the selected image in the pictureBox
                pictureBox1.Image = selectedImage;
            }
        }
        /// <summary>
        /// Handles the picture box click event.
        /// </summary>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Check if an image is selected
            if (pictureBox1.Image != null)
            {
                List<ImageModel> imageCollection = _imageController.GetImageCollection();
                // Find the ImageModel corresponding to the current image in the PictureBox
                ImageModel selectedImageModel = imageCollection.Find(image => image.Image == pictureBox1.Image);

                // Set the selected image in the ImageController
                _imageController.SetSelectedImage(selectedImageModel);
            }
        }

        /// <summary>
        /// Handles the "Rotate" button click event.
        /// </summary>
        private void RotateButton_Click(object sender, EventArgs e)
        {
            // Check if an image is selected
            if (_imageController.GetSelectedImage() != null)
            {
                // Rotate the selected image
                _imageController.RotateImage();

                // Update the image display
                pictureBox1.Image = _imageController.GetSelectedImage().Image;
            }
            else
            {
                // Show a message to inform the user to select an image first
                MessageBox.Show("Please select an image to rotate.");
            }
        }
        /// <summary>
        /// Handles the event when the Flip button is clicked.
        /// Checks if an image is selected and flips the selected image.
        /// Updates the image display accordingly.
        /// </summary>
        private void FlipButton_Click(object sender, EventArgs e)
        {
            // Check if an image is selected
            if (_imageController.GetSelectedImage() != null)
            {
                // Flip the selected image
                _imageController.FlipImage();

                // Update the image display
                pictureBox1.Image = _imageController.GetSelectedImage().Image;
            }
            else
            {
                // Show a message to inform the user to select an image first
                MessageBox.Show("Please select an image to flip.");
            }
        }



        /// <summary>
        /// Handles the event when the Next button is clicked.
        /// Retrieves the thumbnails list and updates the index to display the next image.
        /// Updates the image display accordingly.
        /// </summary>
        private void NextButton_Click(object sender, EventArgs e)
        {
            List<Image> thumbnails = _imageController.GetImageThumbnails();

            if (thumbnails.Count > 0)
            {
                _currentIndex++;
                if (_currentIndex >= thumbnails.Count)
                {
                    _currentIndex = 0;
                }
                pictureBox1.Image = thumbnails[_currentIndex];
            }
        }
        /// <summary>
        /// Handles the event when the Previous button is clicked.
        /// Retrieves the thumbnails list and updates the index to display the previous image.
        /// Updates the image display accordingly.
        /// </summary
        private void PreviousButton_Click(object sender, EventArgs e)
        {
            List<Image> thumbnails = _imageController.GetImageThumbnails();

            if (thumbnails.Count > 0)
            {
                _currentIndex--;
                if (_currentIndex < 0)
                {
                    _currentIndex = thumbnails.Count - 1;
                }
                pictureBox1.Image = thumbnails[_currentIndex];
            }
        }



    }
}


