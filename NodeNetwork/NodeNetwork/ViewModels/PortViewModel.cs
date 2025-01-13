using NodeNetwork.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace NodeNetwork.ViewModels
{
    public class PortViewModel: ReactiveObject
    {

        static PortViewModel()
        {
            NNViewRegistrar.AddRegistration(() => new PortView(), typeof(IViewFor<PortViewModel>));
        }

        #region Parent
        public EndPoint Parent
        {
            get => _parent;
            set => this.RaiseAndSetIfChanged(ref _parent, value);
        }
        private EndPoint _parent;
        #endregion
        #region IsVisible
        public bool IsVisible
        {
            get => _isVisible;
            set => this.RaiseAndSetIfChanged(ref _isVisible, value);
        }
        private bool _isVisible;
        #endregion

        #region IsHighlighted
        public bool IsHighlighted
        {
            get => _isHighlighted;
            set => this.RaiseAndSetIfChanged(ref _isHighlighted, value);
        }
        private bool _isHighlighted;
        #endregion
       
        #region ConnectionDragStarted
        //ドラッグ開始ストリーム。本クラスから配信される情報を購読したい人がSubscribeする。
        //IObservable<Unit>にしている理由はSubjectだと外部で配信処理を実行されてしまうことを防ぐため
        //ドラッグが開始されたことを配信する為、データとしては存在しないのでUnitを使用している
        public IObservable<Unit> ConnectionDragStarted => _connetionDragStarted;
        private readonly Subject<Unit> _connetionDragStarted = new Subject<Unit>();
        #endregion
        public PortViewModel() 
        {
            IsVisible = true;
        }

        //portドラッグ開始
        public void OnDragFromPort()
        {
            _connetionDragStarted.OnNext(Unit.Default);
        }

        //portに触れた時
        public void OnPortEnter()
        {
            IsHighlighted = true;

            PendingConnectionViewModel pendingConnection = Parent.Parent?.Parent?.PendingConnection;//Parentは確実にnullではないが、それ以降はnullの可能性もあるので例外を発生させずにnullを返すようにnull条件演算子を使っている

        }




    }
}
