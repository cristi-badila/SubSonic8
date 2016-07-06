namespace Client.Common.Results
{
    using System.Collections.Generic;
    using Caliburn.Micro;

    public static class ResultExtensionsMethods
    {
        #region Public Methods and Operators

        public static void Execute(this IEnumerable<IResult> results, ActionExecutionContext context = null)
        {
            var coroutineExecutionContext = new CoroutineExecutionContext();
            if (context != null)
            {
                coroutineExecutionContext.Source = context.Source;
                coroutineExecutionContext.Target = context.Target;
                coroutineExecutionContext.View = context.View;
            }

            new SequentialResult(results.GetEnumerator()).Execute(coroutineExecutionContext);
        }

        #endregion
    }
}