import { createStyles, css } from "antd-style";

export const useStyles = createStyles({
    Container: css`
    .ant-modal-content {
      background-color: #44a08d;
      border-radius: 12px;
      color: #ffffff;
    }

    .ant-modal-header {
      background-color: #44a08d;
      border-bottom: 0.1rem solid #ccd0cf;
    }

    .ant-modal-title {
      color: #ffffff;
    }

    .ant-modal-footer {
      border-top: none;
    }
  `
});