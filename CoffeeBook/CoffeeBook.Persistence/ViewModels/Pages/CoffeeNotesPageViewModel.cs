using CoffeeBook.Domain.Entities;
using CoffeeBook.Domain.Enums;
using CoffeeBook.Persistence.Helpers;
using CoffeeBook.Persistence.Services;
using CoffeeBook.Persistence.ViewModels.Base;
using CoffeeBook.Persistence.ViewModels.Controls;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CoffeeBook.Persistence.ViewModels.Pages
{
    public class CoffeeNotesPageViewModel : BaseViewModel
    {
        private readonly IBaseService<Note> _noteService;
        private readonly IBaseService<Coffee> _coffeeService;
        public ObservableCollection<CoffeeNoteViewModel> Notes { get; set; } = new ObservableCollection<CoffeeNoteViewModel>();
        public ObservableCollection<Coffee> Coffees { get; set; } = new ObservableCollection<Coffee>();
        public string NewNoteName { get; set; }
        public string NewNoteDescription { get; set; }
        public ICommand AddNewNoteCommand { get; set; }
        public ICommand DeleteNotesCommand { get; set; }

        private IList<BrewingTypeEnum> _brewingTypes = new List<BrewingTypeEnum>()
        {
            BrewingTypeEnum.Drip,
            BrewingTypeEnum.Chemex,
            BrewingTypeEnum.FrenchPress,
            BrewingTypeEnum.AeroPress,
            BrewingTypeEnum.Syphon,
            BrewingTypeEnum.Machine,
            BrewingTypeEnum.NormalSpilling
        };

        public IEnumerable<BrewingTypeEnum> BrewingTypes
        {
            get { return _brewingTypes; }
            set { }
        }

        private BrewingTypeEnum _selectedBrewingType;

        public BrewingTypeEnum SelectedBrewingType
        {
            get { return _selectedBrewingType; }
            set
            {
                _selectedBrewingType = value;
                OnPropertyChanged("SelectedBrewingType");
            }
        }

        private Coffee _selectedCoffee;

        public Coffee SelectedCoffee
        {
            get { return _selectedCoffee; }
            set
            {
                _selectedCoffee = value;
                OnPropertyChanged("SelectedCoffee");
            }
        }

        public CoffeeNotesPageViewModel(IBaseService<Note> noteService, IBaseService<Coffee> coffeeService)
        {
            _noteService = noteService;
            _coffeeService = coffeeService;
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
                    BrewedDate = note.BrewedDate,
                    BrewingType = note.BrewingTypeEnum
                });
            }
        }
        public void GetAllCoffees()
        {
            foreach (var coffee in _coffeeService.GetAll())
            {
                Coffees.Add(new Coffee()
                {
                    Name = coffee.Name,
                    Id = coffee.Id
                });
            }
        }

        public void AddNote()
        {
            var newNote = new Note()
            {
                Name = NewNoteName,
                Description = NewNoteDescription,
                CoffeeId = SelectedCoffee.Id,
                BrewedDate = DateTime.Now,
                BrewingTypeEnum = SelectedBrewingType,
                BrewingTime = DateTime.Now
            };
            _noteService.AddEntity(newNote);
            var noteViewModel = new CoffeeNoteViewModel()
            {
                Id = newNote.Id,
                Name = NewNoteName,
                BrewingType = SelectedBrewingType,
                BrewedDate = newNote.BrewedDate
            };
            Notes.Add(noteViewModel);

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
