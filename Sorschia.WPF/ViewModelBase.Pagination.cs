using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Sorschia
{
    partial class ViewModelBase
    {
        public DelegateCommand<string> PaginationNavigateFirstPageCommand { get; private set; }
        public DelegateCommand<string> PaginationNavigatePreviousPageCommand { get; private set; }
        public DelegateCommand<string> PaginationNavigateNextPageCommand { get; private set; }
        public DelegateCommand<string> PaginationNavigateLastPageCommand { get; private set; }

        public ObservableCollection<bool> PaginationFirstPageButtonEnabled { get; } = new ObservableCollection<bool>();
        public ObservableCollection<bool> PaginationPreviousPageButtonEnabled { get; } = new ObservableCollection<bool>();
        public ObservableCollection<bool> PaginationNextPageButtonEnabled { get; } = new ObservableCollection<bool>();
        public ObservableCollection<bool> PaginationLastPageButtonEnabled { get; } = new ObservableCollection<bool>();
        public ObservableCollection<int?> PaginationTaken { get; } = new ObservableCollection<int?>();
        public ObservableCollection<int> PaginationCurrentPage { get; } = new ObservableCollection<int>();
        public ObservableCollection<int> PaginationLastPage { get; } = new ObservableCollection<int>();

        protected void InitializePagination(params int?[] pageSizes)
        {
            if (pageSizes != null && pageSizes.Any())
            {
                PaginationNavigateFirstPageCommand = new DelegateCommand<string>(PaginationNavigateFirstPage);
                PaginationNavigatePreviousPageCommand = new DelegateCommand<string>(PaginationNavigatePreviousPage);
                PaginationNavigateNextPageCommand = new DelegateCommand<string>(PaginationNavigateNextPage);
                PaginationNavigateLastPageCommand = new DelegateCommand<string>(PaginationNavigateLastPage);

                for (int i = 0; i < pageSizes.Length; i++)
                {
                    PaginationTaken.Add(pageSizes[i]);
                    PaginationFirstPageButtonEnabled.Add(default);
                    PaginationPreviousPageButtonEnabled.Add(default);
                    PaginationNextPageButtonEnabled.Add(default);
                    PaginationLastPageButtonEnabled.Add(default);
                    PaginationCurrentPage.Add(default);
                    PaginationLastPage.Add(default);
                }
            }
        }

        private bool TryParsePaginationIndex(string paginationIndexString, out int paginationIndex)
        {
            return int.TryParse(paginationIndexString, out paginationIndex);
        }

        private void PaginationNavigateFirstPage(string paginationIndexString)
        {
            if (TryParsePaginationIndex(paginationIndexString, out int paginationIndex))
            {
                PaginationSearch(paginationIndex, null, PaginationTaken[paginationIndex]);
            }
        }

        private void PaginationNavigatePreviousPage(string paginationIndexString)
        {
            if (TryParsePaginationIndex(paginationIndexString, out int paginationIndex))
            {
                var currentPage = PaginationCurrentPage[paginationIndex];
                var taken = PaginationTaken[paginationIndex];

                PaginationSearch(paginationIndex, (currentPage - 2) * taken, taken);
            }
        }

        private void PaginationNavigateNextPage(string paginationIndexString)
        {
            if (TryParsePaginationIndex(paginationIndexString, out int paginationIndex))
            {
                var currentPage = PaginationCurrentPage[paginationIndex];
                var taken = PaginationTaken[paginationIndex];

                PaginationSearch(paginationIndex, currentPage * taken, taken);
            }
        }

        private void PaginationNavigateLastPage(string paginationIndexString)
        {
            if (TryParsePaginationIndex(paginationIndexString, out int paginationIndex))
            {
                var lastPage = PaginationLastPage[paginationIndex];
                var taken = PaginationTaken[paginationIndex];

                PaginationSearch(paginationIndex, (lastPage - 1) * taken, taken);
            }
        }

        private void PaginationEnableBackwardButtons(int paginationIndex, bool enabled)
        {
            PaginationFirstPageButtonEnabled[paginationIndex] = enabled;
            PaginationPreviousPageButtonEnabled[paginationIndex] = enabled;
        }

        private void PaginationEnableForwardButtons(int paginationIndex, bool enabled)
        {
            PaginationNextPageButtonEnabled[paginationIndex] = enabled;
            PaginationLastPageButtonEnabled[paginationIndex] = enabled;
        }

        private void PaginationEnableButtons(int paginationIndex, int currentPage, int lastPage)
        {
            PaginationEnableBackwardButtons(paginationIndex, currentPage > 1);
            PaginationEnableForwardButtons(paginationIndex, currentPage < lastPage);
        }

        protected void PaginationSetPages(int paginationIndex, int? skipped, int? taken, int totalCount)
        {
            var hasSKipped = skipped > 0;
            var hasTaken = taken > 0;
            var currentPage = 0;
            var lastPage = 0;

            if (totalCount > 0 && hasTaken)
            {
                currentPage = hasSKipped ? Convert.ToInt32(Math.Ceiling((double)skipped.Value / taken.Value)) + 1 : 1;
                lastPage = Convert.ToInt32(Math.Ceiling((double)totalCount / taken.Value));
            }

            PaginationCurrentPage[paginationIndex] = currentPage;
            PaginationLastPage[paginationIndex] = lastPage;

            PaginationEnableButtons(paginationIndex, currentPage, lastPage);
        }

        protected virtual void PaginationSearch(int paginationIndex, int? skip, int? take)
        {
            throw new NotImplementedException("Method must be overridden and implemented if pagination feature is intended");
        }
    }
}
