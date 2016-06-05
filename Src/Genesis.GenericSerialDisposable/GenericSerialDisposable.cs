namespace System.Reactive.Disposables
{
    using System;

    /// <summary>
    /// A generic version of the <see cref="SerialDisposable"/> type.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This class provides a generic version of Reactive Extensions' <see cref="SerialDisposable"/> type. This makes
    /// it easier to access type-specific members of the underlying disposable.
    /// </para>
    /// </remarks>
    /// <typeparam name="T">
    /// The type of the underlying disposable.
    /// </typeparam>
    public sealed class SerialDisposable<T> : ICancelable, IDisposable
        where T : IDisposable
    {
        private readonly SerialDisposable disposable;

        /// <summary>
        /// Creates an instance of the <see cref="SerialDisposable{T}"/> class.
        /// </summary>
        public SerialDisposable()
        {
            this.disposable = new SerialDisposable();
        }

        /// <summary>
        /// Gets a value indicating whether this object has been disposed.
        /// </summary>
        public bool IsDisposed => this.disposable.IsDisposed;

        /// <summary>
        /// Gets or sets the underlying disposable, automatically disposing of any replaced value.
        /// </summary>
        public T Disposable
        {
            get { return (T)this.disposable.Disposable; }
            set { this.disposable.Disposable = value; }
        }

        /// <summary>
        /// Disposes of the underlying observable as well as any future replacements.
        /// </summary>
        public void Dispose() =>
            this.disposable.Dispose();
    }
}