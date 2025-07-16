import { createStyles, css } from 'antd-style';

export const useStyles = createStyles({
  CustomModal: css`
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
    }
  `,

  Input: css`
    background-color: #ffffff;
    color: #000000;
    border-radius: 8px;

    &:hover,
    &:focus-within {
      border-color: #11212d !important;
    }
  `,

  Button: css`
    background-color: #ffffff;
    border: none;
    color: #000000;

    &:hover {
      background-color: #11212d !important;
      color: #ffffff !important;
    }
  `,

  CancelButton: css`
    background-color: transparent;
    color: #ffffff;
    border: 1px solid #ffffff;

    &:hover {
      background-color: #11212d !important;
      color: #ffffff !important;
    }
  `,
});
