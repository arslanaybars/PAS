**Reflection based Plugin Architecture Sample with using c#**

We use plugins for extending our solution without re-compile and distribute it to customers.
basically, we scan manually folder for .dlls, use reflection to find plugin classes and create instances.

This is basic sample understand main logic of plugin architecture. For communication we should implement IPlugin interface to the plugins

developed with using netstandard2.0

*references*
- https://www.youtube.com/watch?v=QV921tSlD7U
