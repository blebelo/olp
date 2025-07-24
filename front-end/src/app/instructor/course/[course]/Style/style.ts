
import { createStyles, css } from 'antd-style';

export const useStyles = createStyles({
  pageContainer: css`
    min-height: 100vh;
    background-color: #44a08d;
    padding: 2rem;
    position: relative;
    display: flex;
    flex-direction: column;
    box-sizing: border-box;

    @media (max-width: 768px) {
      padding: 1rem;
    }
  `,
  decorativeCircle: css`
    position: absolute;
    width: 5rem;
    height: 5rem;
    background: rgba(255, 255, 255, 0.1);
    border-radius: 50%;
    top: 10%;
    left: 10%;
    z-index: 0;
  `,
  decorativeSquare: css`
    position: absolute;
    width: 4rem;
    height: 4rem;
    background: rgba(255, 255, 255, 0.08);
    transform: rotate(45deg);
    bottom: 10%;
    right: 10%;
    z-index: 0;
  `,
  header: css`
    color: #000000;
    font-size: 2.2rem;
    font-weight: bold;
    margin-bottom: 2rem;
    z-index: 1;

    @media (max-width: 768px) {
      font-size: 1.8rem;
      text-align: center;
    }
  `,
  secondary: css`
    color: white;
    font-size: 2rem;
    font-weight: bold;
    margin-bottom: 2rem;
    z-index: 1;

    @media (max-width: 768px) {
      font-size: 1.8rem;
      text-align: center;
    }
  `,
  content: css`
    display: flex;
    gap: 2rem;
    z-index: 1;
    box-sizing: border-box;

    @media (max-width: 768px) {
      flex-direction: column;
      gap: 1.5rem;
      width: 100%;
    }
  `,
  sidebar: css`
    width: 20rem;
    max-width: 100%;
    background-color: rgba(255, 255, 255, 0.1);
    padding: 1.5rem;
    border-radius: 0.5rem;
    color: white;
    box-sizing: border-box;

    @media (max-width: 768px) {
      width: 100%;
      padding: 1rem;
    }
  `,
  lessonItem: css`
    padding: 0.75rem;
    margin-bottom: 0.75rem;
    border-radius: 0.5rem;
    width: 100%;
    background-color: rgba(255, 255, 255, 0.15);
    cursor: pointer;
    transition: background 0.3s;
    display: flex;
    justify-content: space-between;
    align-items: center;

    &:hover {
      background-color: rgba(255, 255, 255, 0.25);
    }
  `,
  completedIcon: css`
    color: #52c41a;
    margin-left: 0.5rem;
  `,
  activeLesson: css`
    background-color: rgba(255, 255, 255, 0.3);
  `,
  quizButton: css`
    margin-top: 2rem;
    width: 100%;
    padding: 0.75rem;
    background-color: #1890ff;
    color: white;
    font-weight: 600;
    font-size: 0.9rem;
    border-radius: 0.5rem;
    text-align: center;
    cursor: pointer;
    box-sizing: border-box;

    @media (max-width: 768px) {
      font-size: 0.85rem;
    }

    &:hover {
      background-color: #40a9ff;
    }
  `,
  mainContent: css`
    flex: 1;
    background-color: rgba(255, 255, 255, 0.3);
    border-radius: 0.75rem;
    padding: 1.5rem;
    width: 100%;
    box-sizing: border-box;

    @media (max-width: 768px) {
      padding: 1rem;
    }
  `,
  lessonTitle: css`
    font-size: 1.5rem;
    font-weight: 600;
    margin-bottom: 1rem;
  `,
  lessonDescription: css`
    margin-bottom: 1.5rem;
    font-size: 1rem;
    color: #333;
  `,
  videoWrapper: css`
    width: 100%;
    max-width: 100%;
    height: 18rem;
    margin-bottom: 1.5rem;

    iframe, video {
      width: 100%;
      height: 100%;
      border-radius: 0.5rem;
    }

    @media (max-width: 768px) {
      height: 12rem;
    }
  `,
  materialWrapper: css`
    margin-top: 1rem;
    display: flex;
    flex-wrap: wrap;
    gap: 1rem;
  `,
  materialLink: css`
    display: flex;
    align-items: center;
    padding: 0.5rem 0.75rem;
    border-radius: 0.4rem;
    margin: 0.5rem;
    background-color: rgba(255, 255, 255, 0.3);
    color: #000;
    font-weight: 500;
    text-decoration: none;
    transition: background-color 0.2s;

    &:hover {
      background-color: #e6f7ff;
    }

    svg {
      margin-right: 0.5rem;
    }
  `,
  completeButton: css`
    margin-top: 1.5rem;
    background-color: #1890ff;
    color: white;
    font-weight: 600;
    font-size: 1rem;
    border-radius: 0.4rem;
    text-align: center;
    cursor: pointer;
    display: inline-block;
    margin-left: 0.5rem;

    &:hover {
      background-color: #73d13d;
    }
  `,

  actionButtonGroup: css`
    display: flex;
    flex-wrap: wrap;
    gap: 1rem;
    align-items: center;
    margin-bottom: 1.5rem;
    margin-top: 1rem;
  `,
  actionButton: css`
    background-color: #1890ff;
    color: white;
    font-weight: 600;
    font-size: 1rem;
    border-radius: 0.4rem;
    padding: 0.5rem 1.2rem;
    text-align: center;
    cursor: pointer;
    border: none;
    transition: background 0.2s;
    box-shadow: 0 2px 8px rgba(0,0,0,0.04);

    &:hover {
      background-color: #40a9ff;
    }
    &:not(:last-child) {
      margin-right: 0.5rem;
    }
  `,

  profileFieldRow: css`
    display: flex;
    align-items: center;
    margin-bottom: 1.2rem;
    gap: 1.2rem;
  `,
  profileFieldLabel: css`
    min-width: 120px;
    font-weight: 500;
    color: #333;
    display: flex;
    align-items: center;
    margin-right: 1.5rem;
    font-size: 1.05rem;
  `,
  profileFieldValue: css`
    font-weight: bold;
    color: #222;
    font-size: 1.08rem;
    word-break: break-word;
  `
});
