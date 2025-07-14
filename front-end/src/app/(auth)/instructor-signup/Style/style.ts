import {createStyles,css} from 'antd-style';

export const useStyles = createStyles({
    Container: css`
        background-color: #fffff;
        display: flex;
        justify-content: center;
        align-items: center;
        margin-top: 4rem;`
    ,
    Form: css`
        background-color: #e3f2fd;
        padding: 2rem;
        border-radius: 1rem;
        border-style: solid;
        border-width: 0.01rem;
        border-color: #7a7a7a;
        justify-items: center;
    `,
    Typography: css`
        font-weight: 500;
        font-size: 2.5rem;
    `,
    Submit: css`
        background-color: #0d47a1;
    `,
    FormItems: css`
        display: block;
        justify-items: center;
    `,
    Input: css `
        width: 16rem;
    `,
    Text: css`
        margin-left: 3rem;
    `
})