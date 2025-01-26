using System.Data.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ProjectManagementSystem.Filters;

namespace ProjectManagementSystem.Data;
//
// public class CancelCommandInterceptor : DbCommandInterceptor
// {
//     CancellationTokenProvider _cancellationTokenProvider;
//     public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(DbCommand command,
//         CommandEventData eventData, InterceptionResult<DbDataReader> result, CancellationToken cancellationToken)
//     {
//         if (_cancellationTokenProvider is null)
//         {
//             return await base.ReaderExecutingAsync(command, eventData, result, cancellationToken);
//         }
//         else
//         {
//             var timeoutCcncellationToken = new CancellationTokenSource(TimeSpan.FromSeconds(10)).Token;
//             var cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeoutCcncellationToken, _cancellationTokenProvider.CancellationToken).Token;
//
//             cancellationToken.Register(command.Cancel);
//             var reader = await command.ExecuteReaderAsync();
//             
//             return InterceptionResult<DbDataReader>.SuppressWithResult(reader);
//         }
//     }
//     
// }