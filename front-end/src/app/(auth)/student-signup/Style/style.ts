import {createStyles,css} from 'antd-style';

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
    padding: 2rem;
    border-radius: 1rem;
    box-shadow: 0 0.5rem 2rem rgba(0, 0, 0, 0.15);
    width: 100%;
    max-width: 32rem;
    z-index: 2;
    color: white;

    @media (max-width: 480px) {
      padding: 1.5rem;
    }
  `,

  brandName: css`
    font-size: 1.75rem;
    font-weight: 600;
    color: white;
    text-align: center;
    margin-bottom: 0.5rem;
    letter-spacing: 1px;
  `,

  title: css`
    font-size: 2.5rem;
    font-weight: bold;
    color: white;
    text-align: center;
    margin-bottom: 2rem;
  `,

  formItem: css`
    margin-bottom: 1.5rem;
  `,

  input: css`
    height: 3rem;
    font-size: 1rem;
    background-color: rgba(255, 255, 255, 0.85);
    border-radius: 0.4rem;
    width: 100%;
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
    color: #ffffff;
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