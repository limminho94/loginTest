using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using System.Windows;
using loginTest.ViewModel.Commands;
using System.Windows.Media.Animation;
using loginTest.Model;
using System.Net.Sockets;
using loginTest.View;

namespace loginTest.ViewModel
{
    class LoginVM 
    {
        // TCP 통신
        private TcpClient _client;
        // model 
        private Member member;

        public string id { get; set; }
        public string pw { get; set; }
        public Command chk { get; set; }

        public void ConnectToServer(string idAddress, int port)
        {
            _client = new TcpClient();
            _client.Connect("10.10.20.116", 12345);
        }
        public LoginVM()
        {
            member = new Member();
            chk = new Command(LoginCheck);

            try
            {
                // 실행 시 서버 연결
                ConnectToServer("10.10.20.116", 12345);
                MessageBox.Show("클라이언트 연결성공");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"서버 연결 실패: {ex.Message}");
            }
        }
        // View의 코드 비하인드에서
        // 버튼 클릭 이벤트 핸들러에 작성한 로직을
        // ViewModel에서 함수로 구현합니다.
        public void LoginCheck()
        {
            if(id == member.ID && pw == member.PW)
            {
                MessageBox.Show("로그인성공");
                Main main = new Main();
                // 메인창 연결
                main.ShowDialog();

            }
            else
            {
                MessageBox.Show("로그인실패");
            }
            
        }
    }
}
