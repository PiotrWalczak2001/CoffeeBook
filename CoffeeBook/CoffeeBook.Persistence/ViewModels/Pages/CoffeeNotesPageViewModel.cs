using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;
using CoffeeBook.Domain.Entities;
using CoffeeBook.Domain.Enums;
using CoffeeBook.Persistence.Helpers;
using CoffeeBook.Persistence.Services;
using CoffeeBook.Persistence.ViewModels.Base;
using CoffeeBook.Persistence.ViewModels.Controls;

namespace CoffeeBook.Persistence.ViewModels.Pages
{
    public class CoffeeNotesPageViewModel : BaseViewModel
    {
        private readonly IBaseService<Note> _noteService;
        public ObservableCollection<CoffeeNoteViewModel> Notes { get; set; } = new ObservableCollection<CoffeeNoteViewModel>();
        public string NewNoteName { get; set; }
        public string NewNoteDescription { get; set; }
        public ICommand AddNewNoteCommand { get; set; }
        public ICommand DeleteNotesCommand { get; set; }

        public CoffeeNotesPageViewModel(IBaseService<Note> noteService)
        {
            _noteService = noteService;
            AddNewNoteCommand = new RelayCommand(AddNote);
            DeleteNotesCommand = new RelayCommand(DeleteSelectedNotes);
        }

        public void GetAllNotes()
        {
            foreach (var note in _noteService.GetAll())
            {
                Notes.Add(new CoffeeNoteViewModel()
                {
                    Id = note.Id,
                    Name = note.Name,
                    Description = note.Description,
                    //
                });
            }
        }
        public void AddNote()
        {
            var newNote = new Note()
            {
                Name = NewNoteName,
                Description = NewNoteDescription,
                CoffeeId = 1,
                BrewedDate = DateTime.Now,
                BrewingTypeEnum = BrewingTypeEnum.Chemex,
                BrewingTime = DateTime.Now
            };
            var noteViewModel = new CoffeeNoteViewModel()
            {
                Name = NewNoteName,
                Description = NewNoteDescription,
            };
            Notes.Add(noteViewModel);
            _noteService.AddEntity(newNote);

            NewNoteName = string.Empty;
            NewNoteDescription = string.Empty;

           OnPropertyChanged(nameof(NewNoteName));
           OnPropertyChanged(nameof(NewNoteDescription));
        }

        private void DeleteSelectedNotes()
        {
            var selectedNotes = Notes.Where(x => x.IsSelected).ToList();
            foreach (var note in selectedNotes)
            {
                _noteService.DeleteEntityById(note.Id);
                Notes.Remove(note);
            }
        }
    }
}
