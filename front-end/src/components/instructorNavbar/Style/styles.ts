import { createStyles, css } from 'antd-style';

export const useStyles = createStyles({
  navbar: css`
    background-color: #44a08d;
    padding: 1rem 2rem;
    display: flex;
    justify-content: space-between;
    align-items: center;
    color: white;
    position: sticky;
    top: 0;
    z-index: 1000;

    @media (max-width: 768px) {
      padding: 1rem;
    }
  `,
  logo: css`
    font-size: 1.6rem;
    font-weight: bold;
    color: white;
  `,
  navLinks: css`
    display: flex;
    gap: 1rem;

    @media (max-width: 768px) {
      display: none;
    }
  `,
  navButton: css`
    padding: 0.5rem 1rem;
    background-color: white;
    color: #44a08d;
    font-size: 0.95rem;
    font-weight: 600;
    border: none;
    border-radius: 0.5rem;
    cursor: pointer;
    transition: background 0.3s;

    &:hover {
      background-color: #e6f7f3;
    }
  `,
  menuButton: css`
    display: none;

    @media (max-width: 768px) {
      display: inline-block;
      color: white;
      font-size: 1.2rem;
    }
  `,
  drawer: css`
    .ant-drawer-body {
      padding: 1rem;
      background-color: #44a08d;
      display: flex;
      flex-direction: column;
      gap: 1rem;
    }
  `,
  drawerContent: css`
    display: flex;
    flex-direction: column;
    gap: 1rem;
    align-items: flex-start;
  `,
  drawerLink: css`
    padding: 0.6rem 1.2rem;
    background-color: white;
    color: #44a08d;
    font-weight: 600;
    font-size: 1rem;
    border: none;
    border-radius: 0.5rem;
    cursor: pointer;
    width: 100%;
    text-align: left;
    transition: background 0.3s;

    &:hover {
      background-color: #e6f7f3;
    }
  `,
});
