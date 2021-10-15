
namespace client
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxEncMsg = new System.Windows.Forms.TextBox();
            this.textBoxMsg = new System.Windows.Forms.TextBox();
            this.labelMyA = new System.Windows.Forms.Label();
            this.textBoxMsgInput = new System.Windows.Forms.TextBox();
            this.buttonMsgSend = new System.Windows.Forms.Button();
            this.labelSymmetricKey = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxEncMsg
            // 
            this.textBoxEncMsg.Location = new System.Drawing.Point(519, 88);
            this.textBoxEncMsg.Multiline = true;
            this.textBoxEncMsg.Name = "textBoxEncMsg";
            this.textBoxEncMsg.Size = new System.Drawing.Size(489, 450);
            this.textBoxEncMsg.TabIndex = 0;
            // 
            // textBoxMsg
            // 
            this.textBoxMsg.Location = new System.Drawing.Point(12, 88);
            this.textBoxMsg.Multiline = true;
            this.textBoxMsg.Name = "textBoxMsg";
            this.textBoxMsg.Size = new System.Drawing.Size(489, 450);
            this.textBoxMsg.TabIndex = 0;
            // 
            // labelMyA
            // 
            this.labelMyA.AutoSize = true;
            this.labelMyA.Location = new System.Drawing.Point(12, 9);
            this.labelMyA.Name = "labelMyA";
            this.labelMyA.Size = new System.Drawing.Size(98, 12);
            this.labelMyA.TabIndex = 2;
            this.labelMyA.Text = "my secret key : ";
            // 
            // textBoxMsgInput
            // 
            this.textBoxMsgInput.Location = new System.Drawing.Point(12, 545);
            this.textBoxMsgInput.Name = "textBoxMsgInput";
            this.textBoxMsgInput.ReadOnly = true;
            this.textBoxMsgInput.Size = new System.Drawing.Size(383, 21);
            this.textBoxMsgInput.TabIndex = 4;
            this.textBoxMsgInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxMsgInput_KeyDown);
            // 
            // buttonMsgSend
            // 
            this.buttonMsgSend.Location = new System.Drawing.Point(402, 544);
            this.buttonMsgSend.Name = "buttonMsgSend";
            this.buttonMsgSend.Size = new System.Drawing.Size(99, 21);
            this.buttonMsgSend.TabIndex = 6;
            this.buttonMsgSend.Text = "send";
            this.buttonMsgSend.UseVisualStyleBackColor = true;
            this.buttonMsgSend.Click += new System.EventHandler(this.buttonMsgSend_Click);
            // 
            // labelSymmetricKey
            // 
            this.labelSymmetricKey.Location = new System.Drawing.Point(12, 30);
            this.labelSymmetricKey.Name = "labelSymmetricKey";
            this.labelSymmetricKey.Size = new System.Drawing.Size(996, 55);
            this.labelSymmetricKey.TabIndex = 2;
            this.labelSymmetricKey.Text = "symmetric key : ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 578);
            this.Controls.Add(this.buttonMsgSend);
            this.Controls.Add(this.textBoxMsgInput);
            this.Controls.Add(this.labelSymmetricKey);
            this.Controls.Add(this.labelMyA);
            this.Controls.Add(this.textBoxMsg);
            this.Controls.Add(this.textBoxEncMsg);
            this.Name = "Form1";
            this.Text = "chat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxEncMsg;
        private System.Windows.Forms.TextBox textBoxMsg;
        private System.Windows.Forms.Label labelMyA;
        private System.Windows.Forms.TextBox textBoxMsgInput;
        private System.Windows.Forms.Button buttonMsgSend;
        private System.Windows.Forms.Label labelSymmetricKey;
    }
}

