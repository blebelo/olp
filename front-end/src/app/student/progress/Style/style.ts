import { createStyles, css } from 'antd-style';

export const useStyles = createStyles({
  pageContainer: css`
    min-height: 100vh;
    background-color: #44a08d;
    padding: 2rem;
    position: relative;

    @media (max-width: 768px) {
      padding: 1rem;
    }
  `,
  pageTitle: css`
    color: white;
    font-size: 2.2rem;
    font-weight: bold;
    margin-bottom: 2rem;
    z-index: 1;
  `,
  courseList: css`
    display: flex;
    flex-direction: column;
    gap: 1.5rem;
    z-index: 1;
  `,
  courseCard: css`
    background-color: white;
    border-radius: 0.75rem;
    padding: 1.5rem;
    display: flex;
    justify-content: space-between;
    align-items: flex-start;
    gap: 2rem;
    flex-wrap: wrap;

    @media (max-width: 768px) {
      flex-direction: column;
    }
  `,
  courseDetails: css`
    flex: 1;
  `,
  courseTitle: css`
    font-size: 1.4rem;
    color: #333;
  `,
  courseDescription: css`
    font-size: 1rem;
    color: #555;
    margin-bottom: 1rem;
  `,
  progressContainer: css`
    display: flex;
    flex-direction: column;
    gap: 0.5rem;
  `,
  progressBar: css`
    max-width: 300px;

    @media (max-width: 768px) {
      max-width: 100%;
    }
  `,
  completionText: css`
    font-weight: 500;
    color: #333;
    font-size: 1rem;
  `,
  completed: css`
    color: green;
    font-weight: 600;
    margin-left: 0.5rem;
  `,
  actionSection: css`
    display: flex;
    align-items: center;
    justify-content: flex-end;

    @media (max-width: 768px) {
      justify-content: flex-start;
    }
  `,
  actionButton: css`
    background-color: #1890ff;
    border: none;
    font-weight: 600;
    font-size: 1rem;

    &:hover {
      background-color: #40a9ff;
    }
  `,
  decorativeCircle: css`
    position: absolute;
    width: 5rem;
    height: 5rem;
    background: rgba(255, 255, 255, 0.1);
    border-radius: 50%;
    top: 5%;
    left: 5%;
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
});