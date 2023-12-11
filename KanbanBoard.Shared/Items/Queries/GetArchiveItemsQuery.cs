using KanbanBoard.Shared.Models;
using MediatR;
using System.Collections.Generic;

namespace KanbanBoard.Shared.Items.Queries;

public class GetArchiveItemsQuery : IRequest<IEnumerable<Item>> { }
