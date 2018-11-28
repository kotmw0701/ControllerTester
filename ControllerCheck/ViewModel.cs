using SlimDX.XInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ControllerCheck {
    public class ViewModel : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaizePropertyChanged([CallerMemberName]string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public short XRotation {
            get => _xRotation;
            set {
                _xRotation = value;
                RaizePropertyChanged(nameof(XRotation));
            }
        }
        public short YRotation {
            get => _yRotation;
            set {
                _yRotation = value;
                RaizePropertyChanged(nameof(YRotation));
            }
        }
        public short X {
            get => _x;
            set {
                _x = value;
                RaizePropertyChanged(nameof(X));
            }
        }
        public short Y {
            get => _y;
            set {
                _y = value;
                RaizePropertyChanged(nameof(Y));
            }
        }

        private readonly Controller controller;
        private short _xRotation;
        private short _yRotation;
        private short _x;
        private short _y;


        public ViewModel() {
            controller = new Controller(UserIndex.One);
        }

        public void Tick(object sender, EventArgs args) {
            var gamePad = controller.GetState().Gamepad;
            XRotation = (short)Math.Floor((double)(gamePad.LeftThumbX / 10000));
            YRotation = (short)Math.Floor((double)(gamePad.LeftThumbY / 10000));
            X = (short)Math.Floor((double)(gamePad.RightThumbX / 10000));
            Y = (short)Math.Floor((double)(gamePad.RightThumbY / 10000));
        }


    }
}