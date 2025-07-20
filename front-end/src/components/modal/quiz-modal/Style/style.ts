import { createStyles, css } from "antd-style";

export const useStyles = createStyles({
    Container: css `
    .ant-modal-content {
      background-color: #4a5c6a;
      border-radius: 12px;
      color: #ffffff;
    }

    .ant-modal-header {
      background-color: #4a5c6a;
      border-bottom: 0.1rem solid #ccd0cf;
    }

    .ant-modal-title {
      color: #ffffff;
      
    }

    .ant-modal-footer {
      border-top: none;
   
    `,
    QuestionBlock: css`
        margin-bottom: 24px;
        border: 1px solid #ccc;
        padding: 16px;
        border-radius: 12px;
        background-color: #f5f5f5;
  `,
    OptionInput: css`
        margin-bottom: 12px;
  `,
    AddButton: css`
        margin-top: 16px;
  `,
    QuestionTitle: css`
        font-weight: bold;
        font-size: 16px;
        margin-bottom: 12px;
  `,
});