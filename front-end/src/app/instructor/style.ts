import { createStyles, css } from 'antd-style';

export const useStyles = createStyles({
    Container: css`
        background-color: #9ba8ab;
        min-height: 100vh;
        padding: 3rem;
        display: flex;
        flex-direction: column;
        gap: 2rem;
        align-items: center;
       
    `,
    CardContainer: css`
        background-color: #4a5c6a;
        border-radius: 1rem;
        width: 70%;
        box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
        color: #ffffff;

        .ant-card-head-title {
        color: #ccd0cf;
        font-weight: bold;
    }
    `,
    Button: css`
        background-color: #ffffff;
        margin-right: 0.5rem;
        margin-top: 1rem;
        border: none;
        color: #000000;

        &:hover {
            background-color: #11212d !important;
        }
    `,
    Heading: css`
    color: #ffffff;
    font-size: 2rem;
    font-weight: bold;
    margin-bottom: 1.5rem;
    text-align: center;
`
});
