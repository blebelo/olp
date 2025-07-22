import { createStyles, css } from "antd-style";

export const useStyles = createStyles({
  page: css`
    display: flex;
    justify-content: center;
    padding: 40px;
    background-color: #4ecdc4;
    min-height: 100vh;
  `,
  card: css`
    width: 100%;
    max-width: 700px;
    background: white;
    padding: 32px;
    border-radius: 16px;
    box-shadow: 0 8px 24px rgba(0, 0, 0, 0.06);
  `,
  title: css`
    text-align: center;
    color: #333;
  `,
  questions: css`
    margin-top: 24px;
  `,
  questionBlock: css`
    padding: 20px;
    border-radius: 12px;
    background: #4ecdc4;
    border: 1px solid #4ecdc4;
  `,
  questionText: css`
    font-weight: 500;
    margin-bottom: 12px;
    display: block;
  `,
  options: css`
    display: flex;
    flex-direction: column;
    gap: 10px;
    margin-top: 10px;
  `,
  submit: css`
    align-self: flex-end;
    margin-top: 24px;
  `,
});
