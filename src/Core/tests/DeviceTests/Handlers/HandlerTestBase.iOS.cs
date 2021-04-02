using System;
using System.Threading.Tasks;
using Microsoft.Maui.DeviceTests.Stubs;
using UIKit;
using Xunit;

namespace Microsoft.Maui.DeviceTests
{
	public partial class HandlerTestBase<THandler, TStub>
	{
		protected THandler CreateHandler(IView view)
		{
			var handler = Activator.CreateInstance<THandler>();
			handler.SetMauiContext(MauiContext);

			handler.SetVirtualView(view);
			view.Handler = handler;

			return handler;
		}

		protected string GetAutomationId(IViewHandler viewHandler) =>
			((UIView)viewHandler.View).AccessibilityIdentifier;

		protected string GetSemanticDescription(IViewHandler viewHandler) =>
			((UIView)viewHandler.View).AccessibilityLabel;

		protected string GetSemanticHint(IViewHandler viewHandler) =>
			((UIView)viewHandler.View).AccessibilityHint;
	}
}