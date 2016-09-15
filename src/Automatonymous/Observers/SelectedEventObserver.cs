// Copyright 2011-2016 Chris Patterson, Dru Sellers
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace Automatonymous.Observers
{
    using System;
    using System.Threading.Tasks;
    using GreenPipes.Util;


    class SelectedEventObserver<TInstance> :
        EventObserver<TInstance>
    {
        readonly Event _event;
        readonly EventObserver<TInstance> _observer;

        public SelectedEventObserver(Event @event, EventObserver<TInstance> observer)
        {
            _event = @event;
            _observer = observer;
        }

        public Task PreExecute(EventContext<TInstance> context)
        {
            if (_event.Equals(context.Event))
                return _observer.PreExecute(context);

            return TaskUtil.Completed;
        }

        public Task PreExecute<T>(EventContext<TInstance, T> context)
        {
            if (_event.Equals(context.Event))
                return _observer.PreExecute(context);

            return TaskUtil.Completed;
        }

        public Task PostExecute(EventContext<TInstance> context)
        {
            if (_event.Equals(context.Event))
                return _observer.PostExecute(context);

            return TaskUtil.Completed;
        }

        public Task PostExecute<T>(EventContext<TInstance, T> context)
        {
            if (_event.Equals(context.Event))
                return _observer.PostExecute(context);

            return TaskUtil.Completed;
        }

        public Task ExecuteFault(EventContext<TInstance> context, Exception exception)
        {
            if (_event.Equals(context.Event))
                return _observer.ExecuteFault(context, exception);

            return TaskUtil.Completed;
        }

        public Task ExecuteFault<T>(EventContext<TInstance, T> context, Exception exception)
        {
            if (_event.Equals(context.Event))
                return _observer.ExecuteFault(context, exception);

            return TaskUtil.Completed;
        }
    }
}