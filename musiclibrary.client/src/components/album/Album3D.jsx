import React, { useRef, Suspense } from 'react';
import { Canvas, useLoader } from '@react-three/fiber';
import { TextureLoader } from 'three';
import { OrbitControls, OrthographicCamera } from '@react-three/drei';
import AlbumModel from '../../../public/AlbumModel';

const Album3D = ({ frontCoverUrl, backCoverUrl }) => {
    const vite = '../../../public/vite.svg'
    const frontCover = frontCoverUrl ? useLoader(TextureLoader, frontCoverUrl) : vite;
    const backCover = backCoverUrl ? useLoader(TextureLoader, backCoverUrl) : frontCover;

    return (
        <div className="album-3d">
            <Canvas>
                <Suspense fallback={null}>
                    <ambientLight intensity={2} />
                    <directionalLight position={[0, 0, 5]} intensity={2} />
                    <OrthographicCamera>
                        <AlbumModel frontCover={frontCover} backCover={backCover} />
                    </OrthographicCamera>
                    <OrbitControls makeDefault />
                </Suspense>
            </Canvas>
        </div>
    );
};

export default Album3D;
