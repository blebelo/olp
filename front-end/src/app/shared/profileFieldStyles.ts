import { createStyles, css } from 'antd-style';

export const useProfileFieldStyles = createStyles({
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
