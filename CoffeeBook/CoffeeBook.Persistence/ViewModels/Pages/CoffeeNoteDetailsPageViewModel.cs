using CoffeeBook.Domain.Entities;
using CoffeeBook.Domain.Enums;
using CoffeeBook.Persistence.Services;
using CoffeeBook.Persistence.ViewModels.Base;

namespace CoffeeBook.Persistence.ViewModels.Pages
{
    public class CoffeeNoteDetailsPageViewModel : BaseViewModel
    {
        private readonly IBaseService<Note> _noteService;
        public string NoteDetailsName { get; set; }
        public string NoteDetailsDescription { get; set; }
        public int NoteDetailsCoffeeId { get; set; }
        public DateTime NoteDetailsBrewedDate { get; set; }
        public string NoteDetailsBrewingType { get; set; }
        public CoffeeNoteDetailsPageViewModel(IBaseService<Note> noteService)
        {
            _noteService = noteService;
        }
        public void GetNoteDetails(int noteId)
        {
            var noteDetails = _noteService.GetById(noteId);
            NoteDetailsName = noteDetails.Name;
            NoteDetailsDescription = noteDetails.Description;
            NoteDetailsBrewingType = Enum.GetName(typeof(BrewingTypeEnum), noteDetails.BrewingTypeEnum);
            NoteDetailsBrewedDate = noteDetails.BrewedDate;
            NoteDetailsCoffeeId = noteDetails.CoffeeId;
        }
    }
}
