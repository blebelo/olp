import { createStyles, css } from "antd-style";

export const useStyles = createStyles({
    Container: css `
    .ant-modal-content {
      background-color: #44a08d;
      border-radius: 12px;
      color: #ffffff;
    }

    .ant-modal-header {
      background-color: #44a08d;
      margin-bottom: 0.5rem;
    }

    .ant-modal-title {
      color: #ffffff;
      font-size: 1.5rem;
    }

    .ant-modal-footer {
      border-top: none;
   
    `,
    QuestionBlock: css`
        margin-bottom: 24px;
        border: 1px solid #ccc;
        padding: 16px;
        border-radius: 12px;
        background-color: rgba(175, 173, 173, 0.1);
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