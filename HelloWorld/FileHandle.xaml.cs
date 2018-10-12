using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using HelloWorld.Entity;
using Newtonsoft.Json;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HelloWorld
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FileHandle : Page
    {
        private Member currentMember;
        public FileHandle()
        {
            this.currentMember =new Member();
            this.InitializeComponent();
        }

        private async void btn_save(object sender, RoutedEventArgs e)
        {
            currentMember.UserName = this.txt_username.Text;
            currentMember.Email = this.txt_email.Text;
            currentMember.Introduction = this.txt_introduction.Text;

            FileSavePicker savePicker = new FileSavePicker();
            savePicker.SuggestedStartLocation = PickerLocationId.Desktop;
            savePicker.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt" });
            savePicker.SuggestedFileName = "New Document";
            StorageFile file = await savePicker.PickSaveFileAsync();
            string jsonMember = JsonConvert.SerializeObject(this.currentMember);
            await FileIO.WriteTextAsync(file, jsonMember);

        }

        private async void btn_load(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.SuggestedStartLocation = PickerLocationId.Desktop;
            openPicker.FileTypeFilter.Add(".txt");
            StorageFile file = await openPicker.PickSingleFileAsync();
            string content = await FileIO.ReadTextAsync(file);
            Member member = JsonConvert.DeserializeObject<Member>(content);

            this.txt_username.Text = member.UserName;
            this.txt_email.Text = member.Email ;
            this.txt_introduction.Text = member.Introduction;

        }
    }
}
