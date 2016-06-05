namespace Genesis.GenericSerialDisposable.UnitTests
{
    using System;
    using System.Reactive.Disposables;
    using Xunit;

    public sealed class GenericSerialDisposableFixture
    {
        [Fact]
        public void is_disposed_returns_false_if_underlying_serial_disposable_is_not_disposed()
        {
            var sut = new SerialDisposable<IDisposable>();
            Assert.False(sut.IsDisposed);
        }

        [Fact]
        public void is_disposed_returns_true_if_underlying_serial_disposable_is_disposed()
        {
            var sut = new SerialDisposable<IDisposable>();
            sut.Dispose();
            Assert.True(sut.IsDisposed);
        }

        [Fact]
        public void disposable_gets_and_sets_the_underlying_disposable()
        {
            var sut = new SerialDisposable<DisposableStub>();
            var first = new DisposableStub();
            var second = new DisposableStub();

            sut.Disposable = first;
            sut.Disposable = second;

            Assert.True(first.IsDisposed);
            Assert.False(second.IsDisposed);
        }

        #region Supporting Types

        private sealed class DisposableStub : IDisposable
        {
            private bool isDisposed;

            public bool IsDisposed => this.isDisposed;

            public void Dispose()
            {
                this.isDisposed = true;
            }
        }

        #endregion
    }
}