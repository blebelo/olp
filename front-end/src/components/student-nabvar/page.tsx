'use client';

import { useState } from 'react';
import { useRouter } from 'next/navigation';
import { MenuOutlined } from '@ant-design/icons';
import { Button, Drawer } from 'antd';
import { useStyles } from './Style/style';
import { navbarItems } from '@/utils/studentNavbar/navbarItems';
const StudentNavbar = () => {
  const { styles } = useStyles();
  const router = useRouter();
  const [open, setOpen] = useState(false);

  const handleNavigate = (path: string) => {
    router.push(path);
    setOpen(false);
  };

  return (
    <nav className={styles.navbar}>
      <div className={styles.logo}>DevAcademy</div>

      <div className={styles.navLinks}>
        {navbarItems.map((item) => (
          <button
            key={item.label}
            className={styles.navButton}
            onClick={() => handleNavigate(item.path)}
          >
            {item.label}
          </button>
        ))}
      </div>

      <Button className={styles.menuButton} type="text" icon={<MenuOutlined />} onClick={() => setOpen(true)} />

      <Drawer
        placement="right"
        closable
        onClose={() => setOpen(false)}
        open={open}
        className={styles.drawer}
        width={240}
      >
        <div className={styles.drawerContent}>
          {navbarItems.map((item) => (
            <button
              key={item.label}
              className={styles.drawerLink}
              onClick={() => handleNavigate(item.path)}
            >
              {item.label}
            </button>
          ))}
        </div>
      </Drawer>
    </nav>
  );
}

export default StudentNavbar;
