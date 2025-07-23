import { createStyles, css } from 'antd-style';

export const useStyles = createStyles({
  container: css`
    min-height: 100vh;
    display: flex;
    justify-content: center;
    align-items: center;
    background: linear-gradient(135deg, #4ecdc4 0%, #44a08d 100%);
    position: relative;
    overflow: hidden;
    padding: 2rem;
  `,

  formWrapper: css`
  background-color: rgba(255, 255, 255, 0.15);
  backdrop-filter: blur(12px);
  padding: 3rem 4rem;
  border-radius: 1rem;
  box-shadow: 0 0.5rem 2rem rgba(0, 0, 0, 0.15);
  min-width: 24rem;
  z-index: 2;
`,

  title: css`
    font-size: 2.5rem;
    font-weight: bold;
    color: #333;
    text-align: center;
    margin-bottom: 2rem;
  `,

  formItem: css`
    margin-bottom: 1.5rem;
  `,

  input: css`
    height: 3rem;
    font-size: 1rem;
  `,

  submitButton: css`
    background-color: #1890ff !important;
    border-color: #1890ff !important;
    height: 3rem;
    width: 100%;
    font-size: 1.1rem;
    font-weight: 500;
    border-radius: 0.5rem;
  `,

  linkText: css`
    display: block;
    margin-top: 1.5rem;
    text-align: center;
    color: #1890ff;
    font-weight: 500;
  `,

  decorativeCircle: css`
    position: absolute;
    width: 5rem;
    height: 5rem;
    border-radius: 50%;
    background: rgba(0, 0, 0, 0.08);
    z-index: 1;
  `,

  circleTopLeft: css`
    top: 10%;
    left: 10%;
  `,

  circleBottomRight: css`
    bottom: 10%;
    right: 15%;
  `,
});
