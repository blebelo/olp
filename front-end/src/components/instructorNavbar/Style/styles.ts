import { createStyles, css } from 'antd-style';

export const useStyles = createStyles({
    Navbar: css`
        background-color: #06141B;
        display: flex;
        justify-content: space-between;
        align-items: center;
        padding: 0 2rem;
    `,
    NavTitle: css`
        color: #ffffff;
        font-size: 1.5rem;
        font-weight: bold;
    `,
    Menu: css`
    background-color: transparent;

    .ant-menu-item {
        background-color: transparent !important;
        color: #ffffff !important;
    }

    .ant-menu-item-selected {
        background-color:rgb(246, 248, 250) !important;
        color:rgb(0, 0, 0) !important;
    }
`
});